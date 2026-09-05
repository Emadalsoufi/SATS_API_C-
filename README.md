 إليك ملف `README.md` احترافي وجاهز — انسخه مباشرة في الـ repo:

```markdown
# 🎓 SATS — Student Attendance Tracking System



نظام ذكي لتتبع حضور الطلاب في الجامعات باستخدام **QR Code**، مبني على `.NET Web API` بهيكلية **Clean Architecture**.


## 📐 هيكل المشروع

```
SATS/
├── 📁 Domain              → الكيانات (Entities) والعقود (Interfaces)
├── 📁 Application         → المنطق التطبيقي، DTOs، الـ Services
├── 📁 Infrastructure      → قاعدة البيانات (EF Core) والـ Repositories
└── 📁 SATS.API            → الـ Controllers, Endpoints
```

---

## ⚡ الميزات الرئيسية

| الميزة | الوصف |
|--------|-------|
| 🔐 **إدارة المستخدمين** | تسجيل دخول، أدوار (طلاب / محاضرين / مسؤولين) |
| 📚 **إدارة المقررات** | إنشاء وتعديل المقررات الدراسية |
| 📝 **التسجيل الأكاديمي** | تسجيل الطلاب في المقررات |
| 📅 **جلسات الحضور** | فتح جلسات QR للمحاضرات |
| 📲 **مسح QR** | تسجيل الحضور تلقائياً (Present / Late) |
| 🛡️ **Audit Logs** | تتبع جميع العمليات والتعديلات |

---

## 🌐 Endpoints

| Controller | Methods |
|------------|---------|
| `Users` | `GET` `POST` `PUT` |
| `Courses` | `GET` `POST` `PUT` |
| `Enrollments` | `GET` `POST` `DELETE` |
| `AttendanceSessions` | `GET` `POST` `PUT /close` `PUT /cancel` |
| `AttendanceRecords` | `GET` `POST /scan` `PUT` |
| `AuditLogs` | `GET` `POST` |

---

## 🚀 التشغيل

```bash
# 1. استنساخ المستودع
git clone https://github.com/Emadalsoufi/SATS_API_C-.git

# 2. الانتقال للمجلد
cd SATS_API_C-

# 3. استعادة الحزم
dotnet restore

# 4. تطبيق Migration
dotnet ef database update --project Infrastructure --startup-project SATS.API

# 5. التشغيل
dotnet run --project SATS.API
```

> 📌 يفتح التطبيق على `https://localhost:7001` مع Swagger UI.

---

## 🛠️ التقنيات المستخدمة

- **.NET 8** Web API
- **Entity Framework Core** (Code-First)
- **SQL Server**
- **Clean Architecture** (Domain → Application → Infrastructure → API)
- **Dependency Injection**
- **Repository Pattern**

---

## 👥 الفريق

| العضو | المسؤولية |
|-------|-----------|
| عماد | Attendance Sessions |
| محمد عبيه | Attendance Records (Scan Logic) |
| مازن | Users & Audit Logs |
| إبراهيم | Courses |
| عمرو خالد | Enrollments |

---

<div align="center">

**[⬆️ العودة للأعلى](#-sats--student-attendance-tracking-system)**

</div>
```

---

### 📋 خطوات الإضافة:

1. افتح الـ repo على GitHub
2. اضغط **"Add a README"** (أو أنشئ ملف `README.md` يدوياً)
3. الصق الكود فوق
4. اضغط **Commit**

لو تبي أضيف **صورة للـ Swagger** أو **شعار الجامعة** أو **تعليمات Docker** — قول لي! 🚀
