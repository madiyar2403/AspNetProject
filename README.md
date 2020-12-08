# AspNetProject
This is a final project for the course SWD6: MIcrosoft .NET Framework: ASP.NET ApplIcatIon Development. Project is a standard online store selling transports.
Since it is quite popular nowadays, I decided to create this web application. I have several main entities, and these entities have all relationship types:

How site is functioning?
1. Register;
2. Search some transport;
3. Make order;
4. Get checkout;

Entities:
- Type(id, name, description)
- Category(id, name, description, typeId, Type)
- Transport(id, name, weight, capacity, maxSpeed, producer, description, price, imageUrl, categoryId, Category)
- Order(id, firstName, lastName, address, contactPhone, email, dateTime, transportId, Transport)
- IdentityModels:
  - User
  - Role
  
 Validations:
  
 - the remote validation
  
  VerifyName method for checking name of the transport, 'Name' is checked by TransportsController This method checks if the transport name data matches the input data.
  
 - the custom attriubute validation
  
  The custom validation attribute is “PriceAttribute”. He checks the “Price” property of the “Transport” model, making sure that the price is reliable and does not exceed 10000000000000 and not less than 100, the implementation is in the same model.
  
 - the models which implements IValidatableObject
  
  The model 'Type' and model 'Category' inherits IValidatableObject. Validate method checks the name and description if it is empty(white space) or not in both models.

