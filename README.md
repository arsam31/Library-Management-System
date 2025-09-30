# Library Management System

1. Overview
This project is a Library Management System built in ASP.NET Core Web API with SQL Server as the backend. The system manages Books, Members, and Borrow/Return transactions.

It follows a layered architecture:
- Database (Tables + Stored Procedures)
- Repositories (Data Access Layer)
- Managers (Business Logic Layer)
- Controllers (API Layer)
2. Database Design
2.1 Tables
Books Table
Members Table
 LibraryTransactions Table
2.2 Stored Procedures
Books:
- StoredProcedure_AddBook
- StoredProcedure_UpdateBook
- StoredProcedure_DeleteBook
- StoredProcedure_GetAllBooks
- StoredProcedure_GetBookById
Members:
- StoredProcedure_AddMember
- StoredProcedure_UpdateMember
- StoredProcedure_DeleteMember
- StoredProcedure_GetAllMembers
- StoredProcedure_GetMemberById

Library (Borrow/Return):
- StoredProcedure_BorrowBook
- StoredProcedure_ReturnBook
- StoredProcedure_GetBorrowedBooksByMember
3. Repository Layer (Data Access)
Each entity has a Repository Interface + Implementation:
- IBookRepository, BookRepository
- IMemberRepository, MemberRepository
- ILibraryRepository, LibraryRepository

Repositories execute stored procedures using SqlConnection + Dapper.
4. Manager Layer (Business Logic)
Each entity has a Manager Interface + Implementation:
- IBookManager, BookManager
- IMemberManager, MemberManager
- ILibraryManager, LibraryManager

Managers handle:
- Input validation
- Mapping repository results to response models
- Returning standardized responses (status_code + message + data)
5. Controller Layer (API Endpoints)
BooksController:
- POST /api/books/add
- PUT /api/books/update
- DELETE /api/books/delete/{id}
- GET /api/books/all
- GET /api/books/{id}

MembersController:
- POST /api/members/add
- PUT /api/members/update
- DELETE /api/members/delete/{id}
- GET /api/members/all
- GET /api/members/{id}


LibraryController:
- POST /api/library/borrow
- POST /api/library/return
- GET /api/library/member/{id}
6. Dependency Injection Setup (Program.cs)

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookManager, BookManager>();

builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberManager, MemberManager>();

builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
builder.Services.AddScoped<ILibraryManager, LibraryManager>();


7. Static Messages
Books
- Book added successfully.
- Book updated successfully.
- Book deleted successfully.
- Book not found.
- Error while processing book request.
Members
- Member added successfully.
- Member updated successfully.
- Member deleted successfully.
- Member not found.
- Error while processing member request.
Library
- Book borrowed successfully.
- Book returned successfully.
- Member has no borrowed books.
- Book is not available right now.
- Error while processing borrow/return request.
