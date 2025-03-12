#  API
### User

* `POST` `/User/GetUser`
    ```js
    {
        "id": null,
        "email": "string",
        "password": "string",
        "name": null,
        "image": null,
        "type": null
    }
    ```

* `POST` `/User/CreateUser`
   ```js
    {
        "id": null,
        "email": "string",
        "password": "string",
        "name": "string",
        "image": "string",
        "type": "string"
    }
    ```

* `PUT` `/UserUpdateUser`
   ```js
    {
        "id": null,
        "email": "string",
        "password": "string",
        "name": "string",
        "image": "string",
        "type": "string"
    }
   ```

* `DELETE` `/User/DeleteUser`
   ```js
    {
        "id": null,
        "email": "string",
        "password": "string",
        "name": null,
        "image": null,
        "type": null
    }
   ```

### Dish
* `GET` `/Dish/GetAllDishes`
    ```js
    { }
    ```

*  `GET``/Dish/GetAllDishByID`
    ```
    "<dishID>"
    ```

* `POST` `/Dish/CreateDish`
    _creates dish;_ `staff only`
    ```js
    {
        "id": null,
        "name": "string",
        "composition": "string",
        "image": "string",
        "price": int
    }
    ```

* `DELETE` `/Dish/DeleteDish`
    _deletes dish by ID;_ `staff only`
    ```js
    {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "userID": "<staffUserID>",
        "userPassword": "<staffUserPassword>",
        "dishes": null
    }
    ```

### Order
* `POST` `/Order/Create`
    ```js
    {
        "id": null,
        "userID": "<userID>",
        "userPassword": "<userPassword>",
        "dishes": {
            "<dishID>": dishAmount,
            "<dishID>": dishAmount,
            "<dishID>": dishAmount
        }
    }
    ```

* `POST` `/Order/GetAllOrderIDs`
    _returns list of IDs of all existing orders;_ `staff only`
    ```js
    {
        "id": null,
        "userID": "<staffUserID",
        "userPassword": "<staffUserPassword>",
        "dishes": null
    }
    ```

* `POST` `/Order/GetOrderByIDStaff`
    _returns order;_ `staff only`
    ```js
    {
        "id": "<orderID>",
        "userID": "<staffUserID",
        "userPassword": "<staffUserPassword>",
        "dishes": null
    }
    ```

* `POST` `/Order/GetOrderByID`
    ```js
    {
        "id": "<orderID>",
        "userID": "<UserID",
        "userPassword": "<UserPassword>",
        "dishes": null
    }
    ```
* `POST` `/Order/GetOrderIDsByUserID`
    ```js
    {
        "id": null,
        "userID": "<staffUserID>",
        "userPassword": "<staffUserPassword>",
        "dishes": null
    }
    ```

* `DELETE` `/Order/DeleteOrderByID` `staff only`
    ```js
    {
        "id": "<orderID>",
        "userID": "<staffUserID>",
        "userPassword": "<staffUserPassword>",
        "dishes": null
    }
    ```
