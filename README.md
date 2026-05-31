# MyFormApp

MyFormApp is a premium ASP.NET Core MVC web application designed to demonstrate robust form handling, server-side and client-side data validation, and the implementation of the PRG (Post/Redirect/Get) pattern. It features a modern, responsive user interface with animated backgrounds and high-quality typography (Inter font).

## 🚀 Features

- **Comprehensive Data Collection:** Securely collects user information including First Name, Last Name, Email Address, Phone Number, and an optional Message.
- **Strict Data Validation:** Utilizes ASP.NET Core Data Annotations to enforce validation rules:
  - `[Required]`: Ensures mandatory fields (Name, Email) are not left blank.
  - `[EmailAddress]`: Validates the structure of the provided email address.
  - `[Phone]` and `[RegularExpression]`: Ensures the phone number matches specific formats.
  - `[StringLength]`: Prevents abuse by limiting character counts (e.g., maximum 500 characters for the message).
- **PRG Pattern (Post/Redirect/Get):** Implements best practices for web forms by redirecting the user to a summary page after a successful POST request. This prevents duplicate form submissions if the user refreshes the page.
- **State Management with TempData:** Successfully validated data is temporarily stored using `TempData` (serialized via `System.Text.Json`) allowing the data to survive the redirect and be displayed on the Summary page.
- **Modern UI/UX:** Built with Bootstrap for responsive layout, integrated with custom CSS for glassmorphism effects, dynamic animated background orbs, and custom SVG icons for a premium look and feel.

## 📁 Project Structure

### Controllers
- **`FormController`**: The heart of the application's logic.
  - `[HttpGet] InputForm()`: Renders the initial empty form.
  - `[HttpPost] Submit()`: Receives form data, applies validation rules. If invalid, returns the form with error messages. If valid, serializes the data to `TempData` and redirects to the Summary action.
  - `[HttpGet] Summary()`: Deserializes the data from `TempData` and displays the success page. Redirects back to the form if accessed directly without data.

### Models
- **`UserFormModel`**: Defines the data structure (FirstName, LastName, Email, PhoneNumber, Message) and contains all the Data Annotation attributes that dictate the validation rules.

### Views
- **`Shared/_Layout.cshtml`**: The master layout file including the navigation bar, footer, animated background, and global CSS/JS references (Bootstrap, Inter font).
- **`Form/InputForm.cshtml`**: The Razor view containing the HTML form, styled with Bootstrap and custom CSS classes. It utilizes tag helpers (`asp-for`, `asp-validation-for`) to bind the model and display validation errors.
- **`Form/Summary.cshtml`**: The Razor view that displays the submitted, validated data back to the user in a clean, readable format.

## 🛠️ Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) (or later)
- An IDE such as Visual Studio, Visual Studio Code, or Rider.

### Building and Running the Application

1. Open a terminal or command prompt.
2. Navigate to the root project directory:
   ```bash
   cd d:\MyFormApp
   ```
3. Build the application to ensure all dependencies are resolved:
   ```bash
   dotnet build
   ```
4. Run the application:
   ```bash
   dotnet run
   ```
5. **Access the application:** Open your web browser and navigate to the application URL specified in your `launchSettings.json` file. By default, this is:
   - **http://localhost:5100**
   
   The application will automatically route to the default form input page (`/Form/InputForm`).

## 🧪 Testing the Application

1. **Happy Path:** Fill out all required fields with valid data and submit. You should be redirected to the Summary page displaying your data.
2. **Validation Errors:** Try submitting the form empty, or with an invalid email address format. You should see red validation error messages appear instantly.
3. **PRG Pattern Check:** After a successful submission, press `F5` or the refresh button on your browser while on the Summary page. You will not get a "Confirm Form Resubmission" prompt, proving the PRG pattern is working correctly.

## 🐳 Deployment & Containerization (Docker)

This application is fully containerized using **Docker** for standardized, production-ready deployments.

### 🌐 Live Production URL
* **URL**: [https://myform-application.onrender.com](https://myform-application.onrender.com)
* **Hosting Provider**: Render (Free Docker Web Service)

### 1. Build the Docker Image
To package the application into a self-contained Docker container, run the following command from the root directory:
```bash
docker build -t myformapp:latest .
```

### 2. Run the Container Locally
Once built, you can spin up the application in a lightweight container:
```bash
docker run -d -p 8080:8080 --name myformapp_instance myformapp:latest
```
*Access the application at `http://localhost:8080`.*

### ☁️ Hosting in the Cloud (Free Docker Providers)
You can deploy this containerized app completely for free using modern cloud hosting platforms:

* **Render (Free Tier)**: Create a Web Service, link your GitHub repository, choose **Docker** as the environment, and Render will automatically build the container and deploy it publicly.
* **Railway (Free/Developer Trial)**: Sign up, connect your GitHub, and drag-and-drop the repository. Railway will detect the `Dockerfile` and publish your app automatically.
* **Fly.io**: Install the Fly CLI, run `fly launch`, and it will build and deploy the container to their global edge hosting network.

---

## 💻 Technologies Used

- **Backend:** C#, ASP.NET Core MVC 9.0 (with Docker containerization)
- **Frontend:** HTML5, CSS3, Razor Views
- **Frameworks:** Bootstrap (for responsive grid and base components)
- **Serialization:** `System.Text.Json` (for TempData state management)
