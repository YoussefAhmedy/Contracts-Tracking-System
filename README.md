# 📊 Contracts and Warranties Management System

**The Contracts and Warranties Management** System was developed using **ASP.NET Core MVC** with integration to a **SQL Server** database.
The system provides a comprehensive dashboard to view and manage contracts, warranties, and clients with reports and charts that illustrate the status of contracts.

---

## ✨ Main Features
- 📝 **Contract Management**: Add, edit, delete, and search for contracts.
- 👨‍💼 **Client Management**: Link each contract to a specific client with details
- 🛡️ **Warranty Management**: Ability to add warranties related to the contract.
- 📊 **Reports Dashboard**: Charts showing contract status.
- 🔍 **Advanced Search** within contracts and warranties.
- ✅ **Data Validation** before saving.
- 🎨 **User-friendly interface** with a clean design.

---

## 🖼️ Project Screenshots

### 🔹 Home Page
![Home Page](/screenShoots/Home.png)

### 🔹 Contracts Management
![Customers Management](/screenShoots/Customers.png)

### 🔹 Clients Management
![Warranties Management](/screenShoots/Guarantees.png)

### 🔹 Contracts Reports
![Reports](/screenShoots/Reports.png)

---

## 🛠️ Technologies Used
- **Back-End**: ASP.NET Core MVC  
- **Front-End**: HTML, CSS, Bootstrap, Chart.js  
- **Database**: SQL Server  
- **Architecture**: Repository & Unit of Work Pattern  

---

## 🚀 How to Run Locally

1. **Clone the project from GitHub**
   ```bash
   git clone https://github.com/YourUsername/ContractsManagementSystem.git
   ```

2. **Open the project**
   - Open the project using **Visual Studio** or **Rider**.

3. **Update the Database**
   - Create a new database in **SQL Server**. 
   - Update `appsettings.json` with your connection information :
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Server=.;Database=ContractsDB;Trusted_Connection=True;"
     }
     ```

4. **Apply Migrations**
   ```bash
   Update-Database
   ```

5. **Run the project**
   ```bash
   dotnet run
   ```

6. **Access the System**
   Open the browser and navigate to:
   ```
   https://localhost:5001
   ```

---

## 📌 Additional Notes
- All tables are linked with **Relationships** inside the database.
- **Entity Framework Core** was used to handle the data.
- The system supports **Create**, **Update**, and **Delete** with data validation. 
- **The Separation of Concerns** principle was applied using Repository & Unit of Work.

---

## 👨‍💻 Developer
- Name: **[Youssef Ahmedy]**
- Email: **[youssef.ahmedy189@gmail.com]**
- GitHub: [https://github.com/YoussefAhmedy](https://github.com/YoussefAhmedy)

---

⭐ If you liked the project, don’t forget to give the repo a **Star** on GitHub!
