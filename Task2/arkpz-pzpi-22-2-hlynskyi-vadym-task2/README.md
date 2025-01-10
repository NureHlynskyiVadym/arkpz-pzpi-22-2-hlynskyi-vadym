# LevelUp

## Overview
This is README file that describes API configuration, controllers, endpoints and how to interact with them.

## Groups Controller

## Base URL
```
/api/groups
```

## Authentication
Authentication details should be provided by your system administrator.

## Endpoints

### Get Group by ID
Retrieves a specific group by its ID.

```http
GET /api/groups/{id}
```

#### Response
- Success (200 OK)
```json
{
    "success": true,
    "data": {
        "groupId": 1,
        "title": "Group Name",
        "maxMembers": 10
        // other group properties
    }
}
```
- Not Found (404)
```json
{
    "success": false,
    "message": "Group with ID {id} not found."
}
```

### Create Group
Creates a new group.

```http
POST /api/groups
```

#### Request Body
```json
{
    "title": "Group Name",
    "maxMembers": 10
    // other group properties
}
```

#### Response
- Success (201 Created)
```json
{
    "success": true,
    "data": {
        "groupId": 1,
        // created group details
    }
}
```
- Bad Request (400)
```json
{
    "success": false,
    "message": "Group cannot be null"
}
```
- Server Error (500)
```json
{
    "success": false,
    "message": "Error creating the group"
}
```

### Delete Group
Deletes a specific group.

```http
DELETE /api/groups/{id}
```

#### Response
- Success (200 OK)
```json
{
    "success": true
}
```
- Not Found (404)
```json
{
    "success": false,
    "message": "Group with ID {id} not found."
}
```

### Update Group Name
Updates the name of a specific group.

```http
PUT /api/groups/{id}/name
```

#### Request Body
```json
"New Group Name"
```

#### Response
- Success (200 OK)
```json
{
    "success": true,
    "data": {
        "groupId": 1,
        "title": "New Group Name"
        // other group properties
    }
}
```
- Error responses similar to Get Group

### Update Group Max Members
Updates the maximum number of members allowed in a group.

```http
PUT /api/groups/{id}/max-members
```

#### Request Body
```json
10
```

#### Response
Similar to Update Group Name

### Get Groups by User ID
Retrieves all groups associated with a specific user.

```http
GET /api/groups/user/{userId}
```

#### Response
- Success (200 OK)
```json
{
    "success": true,
    "data": [
        {
            "groupId": 1,
            // group details
        },
        // more groups
    ]
}
```
- Not Found (404)
```json
{
    "success": false,
    "message": "No groups found for user with ID {userId}."
}
```

### Get Users in Group
Retrieves all users in a specific group.

```http
GET /api/groups/{groupId}/users
```

#### Response
- Success (200 OK)
```json
{
    "success": true,
    "data": [
        {
            "userId": 1,
            // user details
        },
        // more users
    ]
}
```
- Not Found (404)
```json
{
    "success": false,
    "message": "No users found in group with ID {groupId}."
}
```

### Add User to Group
Adds a user to a specific group.

```http
POST /api/groups/{groupId}/add-user/{userId}
```

#### Response
- Success (200 OK)
```json
{
    "success": true,
    "message": "User successfully added to the group."
}
```
- Not Found (404)
```json
{
    "success": false,
    "message": "Group with ID {groupId} not found."
}
```
- Server Error (500)
```json
{
    "success": false,
    "message": "Error adding user to group."
}
```

## Error Handling
The API uses standard HTTP status codes and returns error messages in a consistent format:
```json
{
    "success": false,
    "message": "Error description"
}
```

## Common Status Codes
- 200: Success
- 201: Created
- 400: Bad Request
- 404: Not Found
- 500: Internal Server Error
