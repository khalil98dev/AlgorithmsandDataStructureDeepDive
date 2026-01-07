# 📊 Graph Representation

Graphs can be represented in **two main ways**, each with its own advantages and trade-offs.

---

## 🔹 1. Adjacency Matrix

> A **2D array** where the element at position `[i][j]` indicates whether there is an edge between vertex _i_ and vertex _j_.

- For **unweighted graphs**:  
  `1` → edge exists, `0` → no edge
- For **weighted graphs**:  
  the value represe# 📊 Graph Representation

Graphs can be represented in **two main ways**, each with its own advantages and trade-offs.

---

## 🔹 1. Adjacency Matrix

> A **2D array** where the element at position `[i][j]` indicates whether there is an edge between vertex _i_ and vertex _j_.

- For **unweighted graphs**:  
  `1` → edge exists, `0` → no edge
- For **weighted graphs**:  
  the value represents the **weight** of the edge

---

### ✨ Example

Graph with **4 vertices**: `A, B, C, D`

|       | A   | B   | C   | D   |
| ----- | --- | --- | --- | --- |
| **A** | 0   | 1   | 0   | 1   |
| **B** | 1   | 0   | 1   | 0   |
| **C** | 0   | 1   | 0   | 1   |
| **D** | 1   | 0   | 1   | 0   |

---

### ✅ Pros

- ⚡ **Fast lookup** to check if an edge exists (`O(1)`)

### ❌ Cons

- 🧠 **Space-intensive** for large graphs with few edges

---

## 🔹 2. Adjacency List

> Each vertex stores a **list of adjacent vertices** it is connected to.

---

### ✨ Example

Graph with vertices `A, B, C, D`:

````text
A: B, D
B: A, C
C: B, D
D: A, C
nts the **weight** of the edge

---

### ✨ Example

Graph with **4 vertices**: `A, B, C, D`

|   | A | B | C | D |
|---|---|---|---|---|
| **A** | 0 | 1 | 0 | 1 |
| **B** | 1 | 0 | 1 | 0 |
| **C** | 0 | 1 | 0 | 1 |
| **D** | 1 | 0 | 1 | 0 |

---

### ✅ Pros
- ⚡ **Fast lookup** to check if an edge exists (`O(1)`)

### ❌ Cons
- 🧠 **Space-intensive** for large graphs with few edges

---

## 🔹 2. Adjacency List

> Each vertex stores a **list of adjacent vertices** it is connected to.

---

### ✨ Example

Graph with vertices `A, B, C, D`:

```text
A: B, D
B: A, C
C: B, D
D: A, C
````
