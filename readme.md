# C# Test

### How to run the solution
```
* Run the API project (CSharpTestAPI) and it will open the API definitions in swagger ui
    http://localhost:50000/swagger/ui/index

* Note: The entity framework has been amened with a seed method to load some 
        sample data to the default database instance. Use the seed method only 
        if you haven't got the database provided in the test.
        This can be enabled in CSharpTestContext.cs if required.


```

### Sample Data & Assumptions

```
* Sample data provided are being loaded to the default db instance
* 3 contollers are created for 3 different users; 
       Orders - for Call Centre User (http://localhost:50000/api/v1/orders), 
       OrderItems - for Finance User (http://localhost:50000/api/v1/orderitems),
       Tyres - for Commercial user (http://localhost:50000/api/v1/tyres)
```