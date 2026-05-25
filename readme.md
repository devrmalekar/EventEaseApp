# 📘 EventEaseApp
* A Blazor Web Assembly Application for Managing Events and Registration

EventEaseApp is a modern event-management application built using **Blazor WebAssembly App (.NET 9.0)** with **Interactive Server Rendering** with the help of **Microsoft Co-pilot to create components, debug and optimize the application**. It demonstrate component-based UI development, form validation, navigation, dependency injection, and state management using custom service.

## 🤖 How Copilot Assisted in This Project

Microsoft Copilot was used throughout the development of EventEaseApp as a coding assistant to improve productivity and support learning. Copilot did not generate the project on its own; instead, it provided guidance, suggestions, and explanations that helped streamline the development process.

### Ways Copilot Assisted:
- **Explaining Blazor Web App concepts**  
  Copilot clarified how Interactive Server Rendering works, how data binding behaves, and how components communicate.

- **Debugging issues**  
  It helped identify why form validation was failing, why event handlers were not firing, and how render modes affect interactivity.

- **Improving code structure**  
  Copilot suggested best practices for organizing components, services, and models in a Blazor Web App.

- **Generating boilerplate code**  
  It assisted with writing repetitive or standard code such as service classes, component templates, and form markup.

- **Providing documentation-style explanations**  
  Copilot helped create clear descriptions for README.md, comments, and architectural explanations.

### What Copilot Did *Not* Do:
- It did not design the project.
- It did not make architectural decisions.
- It did not write the entire codebase.
- It did not replace human understanding or problem‑solving.

Copilot acted as a supportive tool—similar to an intelligent pair‑programming partner—while all final decisions, implementations, and debugging were performed manually.



---

## 🚀 Features

### 🗂 Event Management
= View all upcoming events 
- Add new events using a validated form
- View Event Details
- Register for events

### 🧩  Component-Driven UI
- Reusuable `EventCard` Componenet
` Shared layout with navigation menu
- Page-specific styling using `.razor.css` files

### State Management & Data Handling
- In-memory Event Storage (`EventEaseServer`)
- Session-based user registration tracking (`SessionService`) integrated with Browser Storage (`BrowswerStorageService`)
- Registration management (`RegisterationService`)

### ⚡ Interactive Server Rendering
- Real-time UI updates
- No Javascript required
- Fast and responsive user experience

---

## 🏗 Project Structure

EventEaseApp/
│
├── Layout/
│   ├── MainLayout.razor
│   ├── MainLayout.razor.css
│   ├── NavMenu.razor
│   └── NavMenu.razor.css
│
├── Models/
│   ├── Event.cs
│   └── Register.cs
│
├── Pages/
│   ├── AddEvent.razor
│   ├── AddEvent.razor.css
│   ├── EventCard.razor
│   ├── EventCard.razor.css
│   ├── EventDetail.razor
│   ├── Events.razor
│   ├── Home.razor
│   └── RegisterForEvent.razor
│
├── Services/
│   ├── BrowserStorageService.cs
│   ├── EventEaseService.cs
│   ├── RegistrationService.cs
│   └── SessionService.cs
│
└── wwwroot/
├── css/
│   └── app.css
├── lib/bootstrap/
├── favicon.png
├── icon-192.png
└── index.html

---

## 🧠 Key Components & Pages

### 📄 `Events.razor`
Displays all events using the `EventCard` component.

### ➕ `AddEvent.razor`
A form for adding new events using:
- `EditForm`
- `DataAnnotationsValidator`
- `ValidationMessage`
- Two‑way binding

### 📝 `RegisterForEvent.razor`
Allows users to register for a selected event.

### 🧱 `EventCard.razor`
Reusable card UI for displaying event information.

### 🧭 Layout Components
- `MainLayout.razor` — main page layout  
- `NavMenu.razor` — navigation sidebar  

---

## 🛠 Services

### `EventEaseService`
- Stores events in memory  
- Provides CRUD‑like operations  

### `RegistrationService`
- Handles event registrations  

### `SessionService`
- Tracks user session data  

### `BrowserStorageService`
- Provides access to browser `localStorage` / `sessionStorage`  

---

## 🧪 Validation & Data Binding

EventEaseApp uses **DataAnnotations** for validation.  
Examples of invalid input that cause binding/validation errors:

- Empty event name  
- Invalid date format (e.g., `abc`, `32/13/2024`)  
- Empty location  
- Missing required fields  

Blazor prevents model updates when input is invalid, ensuring safe and predictable form behavior.

---

## ▶️ Running the Project

### 1. Install .NET 9 SDK  
https://dotnet.microsoft.com/download

### 2. Clone the repository

```bash
git clone https://github.com/devrmalekar/EventEaseApp
cd EventEaseApp
```

### 3. Run the application
```bash
dotnet run
```

### 4. Open in browser
--- 
https://localhost:5044
---

## 📌 Future Enhancements 
- User Authentication + Role Based Access Control
- Edit & Delete Events
- Persistent Storage (SQLite or EF Core)
- Toast Notification


