# Exercice-Intégré
Conception from A-Z of a .NET(web API + MVC) app. For the sake of simplicity, we used only the Products, Suppliers and Categories models in the Database.



## API 
Simple REST API wich connects to a sqlite database called Northwind.

### Operation possible :
 
The basic CRUD operations are avaible through the API 


## MVC

MVC architecture for the backend in .NET with C# language. The architecture tries to be the cleanest possible. The components are splitted between the Model, Vue and the Controller

In order to get the Model from the API we created another component in the architecture called the "Services"

### Service component

The services are in charge of calling the web API through HTTP request in order to get the data for the MVC. More precisely, the "Product service" for instance, will call the API with a "get" operation in order to get the list of products and give back the model acquired to the controller.

### Controller component

The controller will be in charge of the getting back the values of the Vue and switch between the different Vues connected to the controller. 

### Model component

The models are here in order the get the link with the models of the API
