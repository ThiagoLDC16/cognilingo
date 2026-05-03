# ListCategories
GET /api/simulations/categories

Payload:
Query Params:
- languageCode: string (Required)

Response:
```json
[
  {
    "id": "uuid",
    "imageUrl": "string?",
    "name": "string",
    "languageCode": "string"
  }
]
```

# ListSituations
GET /api/simulations/categories/{categoryId}/situations

Payload:
Path Params:
- categoryId: uuid
Query Params:
- languageCode: string (Required)

Response:
```json
[
  {
    "id": "uuid",
    "name": "string",
    "description": "string",
    "languageCode": "string"
  }
]
```

# ListSituationVariants
GET /api/simulations/situations/{situationId}/variants

Payload:
Path Params:
- situationId: uuid
Query Params:
- languageCode: string (Required)

Response:
```json
[
  {
    "id": "uuid",
    "name": "string",
    "userContext": "string",
    "languageCode": "string"
  }
]
```

# StartSimulation
POST /api/simulations

Payload:
```json
{
  "variantId": "uuid"
}
```

Response:
"uuid" (SimulationId)

# ListSimulationMessages
GET /api/simulations/{id}/messages

Payload:
Path Params:
- id: uuid (SimulationId)

Response:
```json
[
  {
    "id": "uuid",
    "sender": "integer", // 1: AI, 2: User
    "content": "string",
    "translatedContent": "string?",
    "feedback": {
      "classification": "integer", // 0: Correct, 1: Grammar, 2: Vocabulary, 3: Context, 4: Spelling
      "explanation": "string?",
      "correction": "string?"
    }
  }
]
```

# SendMessage
POST /api/simulations/{id}/messages

Payload:
Path Params:
- id: uuid (SimulationId)
Body:
```json
{
  "content": "string"
}
```

Response:
```json
[
  {
    "id": "uuid",
    "sender": "integer", // 1: AI, 2: User
    "content": "string",
    "translatedContent": "string?",
    "feedback": {
      "classification": "integer", // 0: Correct, 1: Grammar, 2: Vocabulary, 3: Context, 4: Spelling
      "explanation": "string?",
      "correction": "string?"
    }
  }
]
```
