# Local installation guide

1. copy this repo
2. install NuGet packages
3. set your connection string in `program.cs`
 ```c#
    options.UseSqlServer("Server= YOUR SERVER HERE;Database=EmployesDB;" +
        "Trusted_Connection=True;TrustServerCertificate=True");
 ```  
4. launch program :)

## Program Overview
you can upload csv files:
![upload-ezgif com-crop](https://github.com/user-attachments/assets/f1e0c56f-f938-4f42-8d45-efce6a530873)

delete employes:
![delete](https://github.com/user-attachments/assets/35ffc207-a807-4152-9b96-97a0caef71f4)

edit information:
![edit](https://github.com/user-attachments/assets/ac105e5c-6097-4e71-8b7a-61b230118d47)

and sort tables:
![sorting-ezgif com-optimize](https://github.com/user-attachments/assets/e17c024f-fcb4-4ca3-8f7b-2438c93130c8)
