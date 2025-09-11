# 📊 نظام إدارة العقود والضمانات

نظام **إدارة العقود والضمانات** تم تطويره باستخدام **ASP.NET Core MVC** مع ربط بقاعدة بيانات SQL Server.  
يوفر النظام لوحة تحكم متكاملة لعرض وإدارة العقود، الضمانات، والعملاء مع تقارير ورسوم بيانية توضح حالة العقود.

---

## ✨ المميزات الرئيسية
- 📝 **إدارة العقود**: إضافة، تعديل، حذف، والبحث عن العقود.
- 👨‍💼 **إدارة العملاء**: ربط كل عقد بعميل محدد مع تفاصيله.
- 🛡️ **إدارة الضمانات**: إمكانية إضافة ضمانات مرتبطة بالعقد.
- 📊 **لوحة تقارير**: رسوم بيانية (Charts) لحالة العقود.
- 🔍 **بحث متقدم** داخل العقود والضمانات.
- ✅ **تحقق من صحة البيانات (Validation)** قبل الحفظ.
- 🎨 **واجهة سهلة الاستخدام** مع تصميم مرتب.

---

## 🖼️ صور من المشروع

### 🔹 الصفحة الرئيسية
![الصفحة الرئيسية](/screenShoots/Home.png)

### 🔹 إدارة العقود
![إدارة العملاء](/screenShoots/Customers.png)

### 🔹 إدارة العملاء
![إدارة الضمانات](/screenShoots/Guarantees.png)

### 🔹 تقارير العقود
![التقارير](/screenShoots/Reports.png)

---

## 🛠️ التقنيات المستخدمة
- **Back-End**: ASP.NET Core MVC  
- **Front-End**: HTML, CSS, Bootstrap, Chart.js  
- **Database**: SQL Server  
- **Architecture**: Repository & Unit of Work Pattern  

---

## 🚀 كيفية التشغيل محليًا

1. **استنساخ المشروع من GitHub**
   ```bash
   git clone https://github.com/YourUsername/ContractsManagementSystem.git
   ```

2. **فتح المشروع**
   - افتح المشروع باستخدام Visual Studio أو Rider.

3. **تحديث قاعدة البيانات**
   - قم بإنشاء قاعدة بيانات جديدة في SQL Server.  
   - حدث `appsettings.json` بمعلومات الاتصال الخاصة بك:
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Server=.;Database=ContractsDB;Trusted_Connection=True;"
     }
     ```

4. **تطبيق الترحيلات (Migrations)**
   ```bash
   Update-Database
   ```

5. **تشغيل المشروع**
   ```bash
   dotnet run
   ```

6. **الدخول للنظام**
   افتح المتصفح وانتقل إلى:
   ```
   https://localhost:5001
   ```

---

## 📌 ملاحظات إضافية
- جميع الجداول مترابطة مع **علاقات (Relationships)** داخل قاعدة البيانات.  
- تم استخدام **Entity Framework Core** للتعامل مع البيانات.  
- النظام يدعم **الإضافة والتعديل والحذف** مع التحقق من صحة البيانات.  
- تم تطبيق مبدأ **Separation of Concerns** باستخدام Repository & Unit of Work.  

---

## 👨‍💻 المطور
- الاسم: **[Youssef Ahmed]**
- البريد: **[youssef.ahmedy189@gmail.com]**
- GitHub: [https://github.com/YourUsername](https://github.com/YourUsername)

---

⭐ إذا أعجبك المشروع لا تنسَ عمل **Star** للريبو على GitHub!
