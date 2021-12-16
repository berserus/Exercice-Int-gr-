# Exercice-Int-gr-
Conception d'une application .net(web API + MVC)

## API 
Simple API wich connects to a sqlite database called Northwind.

### Operation possible :
 
The basic CRUD operations are avaible through the API


## MVC

MVC architecture for the backend in .NET with C# language. The architecture tries to be the cleanest possible. The component are splitted between the Model, Vue and the Controller

In order to get the Model from the API we created another component in the architecture called the "Services"

### Service component

The services are in charge of calling the web API in order to get the data for the MVC. More precisely, the "product service" for instance, will call the API with a "get" operation 
in order to get the list of products and give back the model acquired back to the controller.

### Controller component

The controller will be in charge of the getting back the values of the Vue 
