# Student API

## Endpoints

### GET /api/students
Get all students with optional filtering and sorting.

**Query Parameters:**
- `birthYearAfter` (optional): Filter students born after this year.
- `birthYearBefore` (optional): Filter students born before this year.
- `sortBy` (optional): Sort by `id`, `name`, or `birthYear`. Append `_desc` for descending order (e.g., `name_desc`).

### GET /api/students/{id}
Get a specific student by ID.

### POST /api/students
Create a new student.

**Request Body:**
```json
{
  "name": "string",
  "birthYear": number
}