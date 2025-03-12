# Shoe Store Management System

A Windows-based inventory management system for a shoe store, developed using **C#** and **Microsoft SQL Server Management Studio (SSMS)**. The system allows users to manage products, categories, and suppliers efficiently.

## Features

- **Dashboard**: Provides an overview of the system.
- **Product Management**: Add, update, delete, and search products with image support.
- **Category Management**: Manage product categories.
- **Supplier Management**: Manage suppliers.
- **User Authentication**: Login/logout functionality.
- **Search and Filter**: Quickly find products by name.

## Technologies Used

- **Programming Language**: C# (Windows Forms Application)
- **Database**: Microsoft SQL Server Management Studio (SSMS)
- **IDE**: Visual Studio

## Installation and Setup

### Prerequisites

- Install **Microsoft SQL Server** and **SQL Server Management Studio (SSMS)**.
- Install **Visual Studio** with C# development environment.

### Steps to Run the Project

1. **Clone the Repository**:
   ```sh
   git clone https://github.com/HafsaRizvi2278/ShoeShopManagementSystem.git
   cd shoe-store-management
   ```
2. **Open the Project**:
   - Open the `.sln` file in Visual Studio.
3. **Configure the Database**:
   - Restore the database backup (`.bak` file) using SSMS.
   - Update the connection string in the `Products.cs` file:
     ```csharp
     SqlConnection conn = new SqlConnection("Server=YOUR_SERVER;Database=Productss;Trusted_Connection=True");
     ```
4. **Run the Application**:
   - Build and run the project in Visual Studio.

## Screenshots
![image](https://github.com/user-attachments/assets/b613c7ed-e90f-419f-8f0a-071b325d1ccc)<br>
![image](https://github.com/user-attachments/assets/052802c9-7319-43ed-b632-43762c485229)<br>
![image](https://github.com/user-attachments/assets/db499bba-c85b-42b9-b15b-f86b990b2262)<br>
![image](https://github.com/user-attachments/assets/f50a9a84-8b50-40e9-b0c2-bd867af5970c)<br>
![image](https://github.com/user-attachments/assets/135aaae2-5a13-4721-8f85-09855e7b8f5f)
<br>
<br>


## License
This project is open-source and available under the [MIT License](LICENSE).

## Author
Developed by **[HafsaRizvi]**.

## Contributions
Contributions are welcome! Feel free to fork the repository and submit pull requests.

## Contact
For any issues or suggestions, open an issue on the GitHub repository.

