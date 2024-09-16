using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CsvHelper;
using System.Globalization;
using System.Formats.Asn1;
using BitOrcTraineeTest.Models;
using Microsoft.EntityFrameworkCore;
using CsvHelper.Configuration;

public class IndexModel : PageModel
{
    private readonly EmployesContext _context;
    public List<Employes> Employes { get; set; } = new List<Employes>();

    public IndexModel(EmployesContext employesContext)
    {
        _context = employesContext;
    }

    // loads employes data on program start
    public async Task<IActionResult> OnGetAsync()
    {
        Employes = await _context.Employes.ToListAsync();
        return Page();
    }

    // CSV load handler
    public async Task<IActionResult> OnPostUploadAsync(IFormFile csvFile)
    {
        if (csvFile != null && csvFile.Length > 0)
        {
            using (var reader = new StreamReader(csvFile.OpenReadStream()))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                // these two lines allow ignoring absence of id field in csv files 
                HeaderValidated = null,
                MissingFieldFound = null
            }))
            {
                var records = csv.GetRecords<Employes>().ToList();
                // save to database
                _context.Employes.AddRange(records);
                await _context.SaveChangesAsync();

                Employes = await _context.Employes.ToListAsync();
            }
        }

        return Page();
    }

    //delete button
    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var employee = await _context.Employes.FindAsync(id);
        if (employee != null)
        {
            // delete employee and save changes to database
            _context.Employes.Remove(employee);
            await _context.SaveChangesAsync();
        }

        // Reload the page with updated data
        Employes = await _context.Employes.ToListAsync();
        return Page();
    }

    //edit button
    public async Task<IActionResult> OnPostEditAsync(int id, string name, DateTime dateOfBirth, bool married, string phone, decimal salary)
    {
        var employee = await _context.Employes.FindAsync(id);
        if (employee != null)
        {
            employee.Name = name;
            employee.DateOfBirth = dateOfBirth;
            employee.Married = married;
            employee.Phone = phone;
            employee.Salary = salary;

            // save to database
            await _context.SaveChangesAsync();
        }

        // Reload the page with updated data
        Employes = await _context.Employes.ToListAsync();
        return Page();
    }


}

