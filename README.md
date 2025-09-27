# 🏡 SmartVilla API  

SmartVilla API is a **learning project** developed with **.NET 8**, designed to showcase how to build a robust, maintainable, and production-ready **RESTful API**.  

The project focuses on managing **villa properties** and user authentication. It provides structured endpoints to handle villas, villa numbers, and users in a clean and scalable way.  

---

##  Purpose  

The purpose of this project is to:  
- Demonstrate **Clean Architecture principles** and **best practices** in ASP.NET Core.  
- Showcase **Repository Pattern** and **Domain Driven Design (DDD)**.  
- Provide a real-world example of **authentication & role-based authorization** using **JWT & ASP.NET Identity**.  
- Expose **RESTful APIs** that can be consumed by front-end applications or mobile apps.  

---

## 🚀 Features  

- ✅ **Entity Framework Core** with **Code First** approach & migrations.  
- ✅ **Repository Pattern** for separation of data access logic.  
- ✅ **Domain Driven Design (DDD)** with clear domain entities.  
- ✅ **CRUD operations** for villa management:  
  - Villas (basic property details, size, rate, amenities).  
  - Villa Numbers (specific unit numbers tied to a villa).  
- ✅ **Local User Management** for authentication.  
- ✅ **Authentication & Role-based Authorization** using **ASP.NET Identity** and **JWT Tokens**.  
- ✅ **AutoMapper** for mapping between Entities and DTOs.  
- ✅ **Validation** using Data Annotations and **FluentValidation**.  
- ✅ **Filtering, Sorting, and Pagination** on villa endpoints.  
- ✅ **API Versioning** to support multiple versions of the API.  
- ✅ **Swagger & Postman** for API testing and documentation.  

---

## 🛠️ Tech Stack  

- [ASP.NET Core 8](https://learn.microsoft.com/en-us/aspnet/core)  
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core)  
- [AutoMapper](https://automapper.org/)  
- [ASP.NET Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity)  
- [JWT Authentication](https://jwt.io/)  
- [FluentValidation](https://docs.fluentvalidation.net/)  
- [Swagger](https://swagger.io/)  
- [Postman](https://www.postman.com/)  

---

## 📂 Domain Entities  

### 🏠 Villa  
Represents a villa property with:  
- **Name**, **Details**, **Rate**, **Sqft (square feet size)**.  
- **ImageUrl** and **Amenity** (comfort features).  
- **CreatedTime** and **UpdatedTime**.  
- Linked to multiple **VillaNumbers**.  

### 🔢 VillaNumber  
Represents a specific villa unit with:  
- **VillaNo** (unique identifier).  
- **SpecialDetails** about the unit.  
- **CreatedTime**, **UpdatedTime**.  
- Linked to a parent **Villa**.  

### 👤 LocalUser  
Represents an application user with:  
- **Name**, **UserName**, **Password**.  
- List of **Roles** (e.g., Admin/User).  
