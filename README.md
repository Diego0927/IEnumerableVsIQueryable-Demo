\# IEnumerable vs IQueryable - .NET 10 + Oracle XE



Proyecto demostrativo desarrollado en .NET 10 y Oracle XE para analizar las diferencias entre `IEnumerable<T>` e `IQueryable<T>` en Entity Framework Core.



\---



\# Objetivo



Demostrar de forma práctica:



\- Ejecución en memoria vs ejecución en base de datos

\- Traducción de LINQ a SQL

\- Deferred Execution

\- Materialización de consultas

\- Impacto en rendimiento

\- Uso de memoria

\- Tracking de entidades

\- Optimización de consultas



\---



\# Tecnologías utilizadas



\- .NET 10

\- C#

\- Entity Framework Core 10

\- Oracle XE 21c

\- Oracle.EntityFrameworkCore

\- LINQ

\- Dependency Injection



\---



\# Arquitectura



```text

Data/

Entities/

Repositories/

Services/

Helpers/

```



\---



\# Escenarios demostrados



\## IQueryable



La consulta se ejecuta en Oracle:



```csharp

\_repository.ObtenerClientesQueryable()

&#x20;          .Where(c => c.Ciudad == "CALI")

&#x20;          .Take(10)

&#x20;          .ToList();

```



SQL generado:



```sql

SELECT ...

FROM CLIENTES

WHERE CIUDAD = 'CALI'

FETCH FIRST 10 ROWS ONLY

```



\---



\## IEnumerable



La tabla completa se carga en memoria:



```csharp

\_repository.ObtenerClientesEnumerable()

&#x20;          .Where(c => c.Ciudad == "CALI")

&#x20;          .Take(10)

&#x20;          .ToList();

```



\---



\# Resultados



\## IQueryable



\- Consulta ejecutada en Oracle

\- Solo se transfieren registros necesarios

\- Menor consumo de memoria

\- Mejor escalabilidad



\## IEnumerable



\- Se cargan 100.000 registros en memoria

\- Mayor uso de RAM

\- Mayor tiempo de ejecución

\- Menor escalabilidad



\---



\# Resultados de rendimiento



| Tipo | Tiempo |

|---|---|

| IQueryable | \~159 ms |

| IEnumerable | \~9568 ms |



\---



\# Cómo ejecutar



1\. Clonar el repositorio

2\. Configurar Oracle XE

3\. Crear tabla CLIENTES

4\. Configurar appsettings.json

5\. Ejecutar el proyecto



\---



\# Autor



Diego Alejandro Giraldo Duque

