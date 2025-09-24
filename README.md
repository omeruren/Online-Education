 Online Education Platform

 **Overview**

Online Education, öğrencilerin çevrim içi kurslara erişebildiği, eğitmenlerin ders içeriklerini ve blog yazılarını yönetebildiği, yöneticilerin ise sistemi denetleyebildiği katmanlı mimariyle geliştirilmiş bir eğitim platformudur.
Proje; Clean Architecture prensipleri ve best practices gözetilerek, UI, API, Business, Data Access, Entity ve DTO katmanlarına ayrılmıştır.


- Separation of Concerns uygulanmıştır.

- Repository Pattern ve Dependency Injection kullanılmaktadır.

- DTO yapısı ile UI/API – Entity katmanı arasında loose coupling sağlanmıştır.

- Role-based authorization (Admin, Student, Instructor/Teacher) desteği vardır.

 **Architecture**
 
OnlineEducation.sln
│
├── OnlineEducation.API        → REST API (authentication, course, blog vb.)
├── OnlineEducation.UI         → Kullanıcı arayüzü
├── OnlineEducation.Business   → İş mantığı (service layer, validation, rules)
├── OnlineEducation.DataAccess → Repository + EF Core ile veri erişimi
├── OnlineEducation.Entity     → Domain varlıkları (User, Course, Blog, Enrollment, ...)
├── OnlineEducation.DTO        → Veri transfer objeleri

**Features**

-  Authentication & Authorization (Role-based: Admin, Student, Teacher)
-  Course Management (Ekleme, silme, düzenleme, kategorilere ayırma)
-  Enrollment System (Öğrencilerin kursa kayıt olması)
-  Lessons & Modules (Kurs içeriği yönetimi)
- Teacher Blog System (Eğitmenler blog yazısı yayınlayabilir)
- RESTful API (Dış istemciler için JSON tabanlı iletişim)


**Technologies**

- Backend: ASP.NET Core Web API

- Frontend: ASP.NET Core MVC (UI katmanı)

- ORM: Entity Framework Core

- Database: Microsoft SQL Server

- Authentication: ASP.NET Identity + Role Based Authorization

- Design Patterns: Repository, DTO, Layered Architecture

**Varlıklar (Entities)**

- About
- AppRole
- AppUser
- Banner
- Blog
- BlogCategory
- Contact
- Course
- CourseCategory
- CourseRegister
- CourseVideo
- Message
- SocialMedia
- Subscriber
- TeacherSocial
- Testimonial

  
