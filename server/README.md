# Cardboard Archivist API

## Resources

### Card
* Base Endpoint: `/card`

#### Get All
Returns the list of all cards in the collection.
* Endpoint: `/card`
* HTTP method: `GET`
* Request body: None
* Response codes: `200 OK`

#### Get by ID
Returns a card based on its ID.
* Endpoint: `/card/{id}`
* HTTP method: `GET`
* Request body: None
* Response codes: `200 OK`, `404 NOT FOUND`

#### Add a card
Creates a new card and adds it to the collection.
* Endpoint: `/card`
* HTTP method: `POST`
* Request body:
    ```JSON
    {
        ReferenceUUID: string,
        DeckUUID: string?
    }
    ```
* Response codes: `201 CREATED`, `400 BAD REQUEST`


#### Update a card
Update an existing card in the collection.
* Endpoint: `/card/{id}`
* HTTP method: `PUT`
* Request body:
    ```JSON
    {
        ReferenceUUID: string,
        DeckUUID: string?
    }
    ```
* Response codes: `200 OK`, `400 BAD REQUEST`, `404 NOT FOUND`

#### Delete a card
Delete an existing card from the collection.
* Endpoint: `/card/{id}`
* HTTP method: `DELETE`
* Request body: None
* Response codes: `204 NO CONTENT`, `404 NOT FOUND`