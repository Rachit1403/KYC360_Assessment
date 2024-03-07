# KYC360_Assessment
# REST API Documentation

## Overview

This REST API provides CRUD (Create, Read, Update, Delete) operations for managing patient data. The API is built using .NET 8 WebAPI and interacts with a SQL Server database. The main entity model used is the `Patient` entity, which includes related entities such as `Address`, `Name`, and `Date`.

## Base URL

The base URL for accessing the API is: `https://your-api-domain.com/api/patients`

## Endpoints

### 1. **Get All Patients**

- **Endpoint:** `GET /api/patients`
- **Description:** Retrieves a list of patients with optional parameters for searching, filtering, pagination, and sorting.
- **Parameters:**
  - `search` (optional): Search term to filter patients based on various fields.
  - `gender` (optional): Gender of the patient.
  - `startDate` and `endDate` (optional): Date range for the `Dates.Date` field.
  - `countries` (optional): List of countries for the `Addresses.AddressCountry` field.
  - `page` (optional): Page number for pagination (default is 1).
  - `pageSize` (optional): Maximum number of items per page (default is 10).
  - `sortBy` (optional): Field to sort by (e.g., "FirstName").
  - `desc` (optional): Sort in descending order if true, ascending if false (default is false).
- **Example:**
  - `GET /api/patients?search=bob%20smith&gender=Male&page=1&pageSize=10&sortBy=FirstName&desc=false`

### 2. **Get Single Patient**

- **Endpoint:** `GET /api/patients/{id}`
- **Description:** Retrieves a single patient based on the provided ID.
- **Parameters:**
  - `id` (required): ID of the patient to retrieve.
- **Example:**
  - `GET /api/patients/123`

### 3. **Add Patient**

- **Endpoint:** `POST /api/patients`
- **Description:** Adds a new patient to the database.
- **Request Body:** JSON object representing the patient entity.
- **Example:**
  ```json
  {
    "Deceased": false,
    "Gender": "Male",
    "Names": [
      {
        "FirstName": "John",
        "MiddleName": "Doe",
        "Surname": "Smith"
      }
    ],
    "Addresses": [
      {
        "AddressLine": "123 Main St",
        "City": "Cityville",
        "Country": "USA"
      }
    ],
    "Dates": [
      {
        "DateType": "Birth",
        "DateValue": "1990-01-01"
      }
    ]
  }
  ```

### 4. **Update Patient**

- **Endpoint:** `PUT /api/patients/{id}`
- **Description:** Updates an existing patient in the database.
- **Parameters:**
  - `id` (required): ID of the patient to update.
- **Request Body:** JSON object representing the updated patient entity.
- **Example:**
  ```json
  {
    "Deceased": true,
    "Gender": "Female",
    "Names": [
      {
        "FirstName": "Jane",
        "MiddleName": "Doe",
        "Surname": "Smith"
      }
    ],
    "Addresses": [
      {
        "AddressLine": "456 Oak St",
        "City": "Townsville",
        "Country": "Canada"
      }
    ],
    "Dates": [
      {
        "DateType": "Birth",
        "DateValue": "1985-05-15"
      }
    ]
  }
  ```

### 5. **Delete Patient**

- **Endpoint:** `DELETE /api/patients/{id}`
- **Description:** Deletes a patient from the database.
- **Parameters:**
  - `id` (required): ID of the patient to delete.
- **Example:**
  - `DELETE /api/patients/456`

## Response Format

The API returns JSON responses in the following format:

```json
{
  "data": {},   // The actual data returned by the API
  "message": "Operation successful.",   // Optional message describing the result
  "statusCode": 200   // HTTP status code indicating the success or failure of the operation
}
```

In case of an error, the response format includes an `error` property:

```json
{
  "error": "Error message here.",
  "statusCode": 400
}
```

