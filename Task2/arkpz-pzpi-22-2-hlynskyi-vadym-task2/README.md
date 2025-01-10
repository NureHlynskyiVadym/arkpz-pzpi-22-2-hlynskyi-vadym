# LevelUp

## Overview
This is README file that describes API configuration, controllers, endpoints and how to interact with them.

# Groups Controller

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

- # Rewards API Documentation

## Overview
The Rewards API provides endpoints for managing rewards and handling reward claims. It enables creating, retrieving, updating, and deleting rewards, as well as managing reward claims by users.

## Base URL
```
/api/rewards
```

## Authentication
Authentication details should be provided by your system administrator.

## Endpoints

### Get All Rewards
Retrieves all available rewards.

```http
GET /api/rewards
```

#### Response
- Success (200 OK)
```json
{
    "success": true,
    "data": [
        {
            "rewardId": 1,
            // reward properties
        },
        // more rewards
    ]
}
```

### Get Reward by ID
Retrieves a specific reward by its ID.

```http
GET /api/rewards/{id}
```

#### Response
- Success (200 OK)
```json
{
    "success": true,
    "data": {
        "rewardId": 1,
        // reward properties
    }
}
```
- Not Found (404)
```json
{
    "success": false,
    "message": "Reward with ID {id} not found."
}
```

### Create Reward
Creates a new reward.

```http
POST /api/rewards
```

#### Request Body
```json
{
    // reward properties
}
```

#### Response
- Success (201 Created)
```json
{
    "success": true,
    "data": {
        "rewardId": 1,
        // created reward details
    }
}
```
- Bad Request (400)
```json
{
    "success": false,
    "message": "Reward cannot be null"
}
```
- Server Error (500)
```json
{
    "success": false,
    "message": "Error creating the reward"
}
```

### Update Reward
Updates an existing reward.

```http
PUT /api/rewards/{id}
```

#### Request Body
```json
{
    "rewardId": 1,
    // updated reward properties
}
```

#### Response
- Success (200 OK)
```json
{
    "success": true,
    "data": {
        // updated reward details
    }
}
```
- Bad Request (400)
```json
{
    "success": false,
    "message": "ID mismatch"
}
```
- Not Found (404)
```json
{
    "success": false,
    "message": "Reward with ID {id} not found."
}
```
- Server Error (500)
```json
{
    "success": false,
    "message": "Error updating the reward"
}
```

### Delete Reward
Deletes a specific reward.

```http
DELETE /api/rewards/{id}
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
    "message": "Reward with ID {id} not found."
}
```

### Claim Reward
Claims a reward for a specific user.

```http
POST /api/rewards/{rewardId}/claim
```

#### Request Body
```json
userId
```

#### Response
- Success (200 OK)
```json
{
    "success": true,
    "message": "Reward successfully claimed!"
}
```
- Bad Request (400)
```json
{
    "success": false,
    "message": "Reward could not be claimed, either it was already claimed or an error occurred."
}
```
- Not Found (404)
```json
{
    "success": false,
    "message": "Reward with ID {rewardId} not found."
}
```

### Get User's Rewards
Retrieves all rewards associated with a specific user.

```http
GET /api/rewards/user/{userId}
```

#### Response
- Success (200 OK)
```json
{
    "success": true,
    "data": [
        {
            "rewardId": 1,
            // reward details
        },
        // more rewards
    ]
}
```
- Not Found (404)
```json
{
    "success": false,
    "message": "No rewards found for user with ID {userId}."
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

# Tasks API Documentation

## Overview
The Tasks API provides endpoints for managing tasks, including creation, assignment, completion, and general task management functionalities.

## Base URL
```
/api/tasks
```

## Authentication
Authentication details should be provided by your system administrator.

## Endpoints

### Get Task by ID
Retrieves a specific task by its ID.

```http
GET /api/tasks/{id}
```

#### Response
- Success (200 OK)
```json
{
    "success": true,
    "data": {
        "taskId": 1,
        // task properties
    }
}
```
- Not Found (404)
```json
{
    "success": false,
    "message": "Task with ID {id} not found."
}
```

### Create Task
Creates a new task.

```http
POST /api/tasks
```

#### Request Body
```json
{
    // task properties
}
```

#### Response
- Success (201 Created)
```json
{
    "success": true,
    "data": {
        "taskId": 1,
        // created task details
    }
}
```
- Bad Request (400)
```json
{
    "success": false,
    "message": "Task cannot be null"
}
```
- Server Error (500)
```json
{
    "success": false,
    "message": "Error creating the task"
}
```

### Update Task
Updates an existing task.

```http
PUT /api/tasks/{id}
```

#### Request Body
```json
{
    "taskId": 1,
    // updated task properties
}
```

#### Response
- Success (200 OK)
```json
{
    "success": true,
    "data": {
        // updated task details
    }
}
```
- Bad Request (400)
```json
{
    "success": false,
    "message": "ID mismatch"
}
```
- Not Found (404)
```json
{
    "success": false,
    "message": "Task with ID {id} not found."
}
```
- Server Error (500)
```json
{
    "success": false,
    "message": "Error updating the task"
}
```

### Delete Task
Deletes a specific task.

```http
DELETE /api/tasks/{id}
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
    "message": "Task with ID {id} not found."
}
```

### Assign Task to User
Assigns a task to a specific user.

```http
POST /api/tasks/{taskId}/assign/{userId}
```

#### Response
- Success (200 OK)
```json
{
    "success": true,
    "message": "Task successfully assigned."
}
```
- Not Found (404)
```json
{
    "success": false,
    "message": "Task with ID {taskId} not found."
}
```
- Server Error (500)
```json
{
    "success": false,
    "message": "Error assigning task to user."
}
```

### Get Tasks Assigned to User
Retrieves all tasks assigned to a specific user.

```http
GET /api/tasks/assigned-to/{userId}
```

#### Response
- Success (200 OK)
```json
{
    "success": true,
    "data": [
        {
            "taskId": 1,
            // task details
        },
        // more tasks
    ]
}
```
- Not Found (404)
```json
{
    "success": false,
    "message": "No tasks assigned to user with ID {userId}."
}
```

### Complete Task
Marks a task as completed by a specific user.

```http
POST /api/tasks/{taskId}/complete
```

#### Request Body
```json
userId
```

#### Response
- Success (200 OK)
```json
{
    "success": true,
    "message": "Task marked as completed."
}
```
- Not Found (404)
```json
{
    "success": false,
    "message": "Task with ID {taskId} or User with ID {userId} not found."
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

# Users API Documentation

## Overview
The Users API provides endpoints for managing user accounts, including authentication, profile management, points/level systems, and group associations.

## Base URL
```
/api/users
```

## Authentication
- Most endpoints are accessible without special permissions
- Some endpoints require administrative access (noted in endpoint descriptions)
- Authentication is handled through the `/authenticate` endpoint

## Endpoints

### Get All Users
Retrieves all users in the system.

```http
GET /api/users
```

#### Response
```json
[
    {
        "userId": 1,
        "name": "John Doe",
        "email": "john@example.com",
        "level": 5,
        "points": 1000,
        "groupId": 1
    },
    // more users
]
```

### Get User by ID
Retrieves a specific user by their ID.

```http
GET /api/users/{id}
```

#### Response
- Success (200 OK): Returns the user object
- Not Found (404): `"User with ID {id} not found."`

### Create User
Creates a new user account.

```http
POST /api/users
```

#### Request Body
```json
{
    "name": "John Doe",
    "email": "john@example.com",
    "password": "securepassword"
    // other user properties
}
```

#### Response
- Success (201 Created): Returns created user
- Bad Request (400): `"User cannot be null"`
- Server Error (500): `"Error adding the user"`

### Delete User
Deletes a user account. Requires Admin role.

```http
DELETE /api/users/{id}
```

#### Authorization
Required role: `Admin`

#### Response
- Success (204 No Content)
- Not Found (404): `"User with ID {id} not found."`
- Unauthorized (401): When not authenticated
- Forbidden (403): When not authorized as Admin

### Update User Name
Updates a user's name.

```http
PUT /api/users/{id}/name
```

#### Request Body
```json
"New User Name"
```

#### Response
- Success (200 OK): Returns updated user
- Not Found (404): `"User with ID {id} not found."`
- Server Error (500): `"Error updating the user's name."`

### Remove User from Group
Removes a user from their current group.

```http
PUT /api/users/{id}/remove-group
```

#### Response
- Success (200 OK): Returns updated user
- Not Found (404): `"User with ID {id} not found."`
- Server Error (500): `"Error removing the user from the group."`

### Add Points to User
Adds points to a user's account.

```http
PUT /api/users/{id}/add-points
```

#### Request Body
```json
100
```

#### Response
- Success (200 OK): Returns updated user
- Not Found (404): `"User with ID {id} not found."`
- Server Error (500): `"Error adding points to the user."`

### Update User Level
Updates a user's level.

```http
PUT /api/users/{id}/level
```

#### Request Body
```json
5
```

#### Response
- Success (200 OK): Returns updated user
- Not Found (404): `"User with ID {id} not found."`
- Server Error (500): `"Error updating the user's level."`

### Authenticate User
Authenticates a user and returns their information.

```http
POST /api/users/authenticate
```

#### Request Body
```json
{
    "email": "user@example.com",
    "password": "userpassword"
}
```

#### Response
- Success (200 OK)
```json
{
    "success": true,
    "message": "Authentication successful.",
    "data": {
        // user object
    }
}
```
- Bad Request (400)
```json
{
    "success": false,
    "message": "Email and password are required."
}
```
- Unauthorized (401)
```json
{
    "success": false,
    "message": "Invalid email or password."
}
```

### Get User Groups
Retrieves all groups associated with a user.

```http
GET /api/users/{id}/groups
```

#### Response
- Success (200 OK)
```json
{
    "success": true,
    "data": [
        {
            "groupId": 1,
            "name": "Group Name",
            // other group properties
        },
        // more groups
    ]
}
```

## Error Handling
The API uses standard HTTP status codes:
- 200: Success
- 201: Created
- 204: No Content
- 400: Bad Request
- 401: Unauthorized
- 403: Forbidden
- 404: Not Found
- 500: Internal Server Error

## User Model Properties
```json
{
    "userId": "integer",
    "name": "string",
    "email": "string",
    "password": "string (hashed)",
    "level": "integer",
    "points": "integer",
    "groupId": "integer?"
}
```
