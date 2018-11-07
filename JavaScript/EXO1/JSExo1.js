function Employee(firstName, last_Name, salary) {

    this.first_Name = firstName;
    this.last_Name = last_Name;
    this.salary = salary;
}

Employee.prototype.inCreaseSalary = function () {
    return this.salary = this.salary + 1000
};

Employee.prototype.employeDetail = function () {
    return 'first_Name : ' + this.first_Name + ' first_Name:  ' + this.first_Name + ' and salary : ' + this.salary;

};


