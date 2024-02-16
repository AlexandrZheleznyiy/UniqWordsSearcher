1 задача.
SELECT MAX(salary) FROM employees;

2 задача.
-----------------

3 задача.
WITH dep_salary AS 
	(SELECT DEPARTMENT_Id, sum(SALARY) AS SALARY
    FROM EMPLOYEE 
	GROUP BY DEPARTMENT_Id)
SELECT DEPARTMENT_Id
FROM dep_salary
WHERE dep_salary.salary = (SELECT max(salary) FROM dep_salary);

4 задача.
SELECT * FROM employees WHERE firstname LIKE 'Р%н';

