//emp-projects
var empSelection = document.getElementById("EmpSSN");
var projectSelection = document.getElementById("project-selection");
var projectItemSelection = document.getElementById("projNum");
var hourSelection = document.getElementById("hours-selection");
var hourItemSelection = document.getElementById("Hours");

console.log("Hello World");

empSelection.addEventListener("change", async () => {
    var empProjectsData = await fetch("http://localhost:5142/project/EditEmpHours_Emp/" + empSelection.value);
    var projectsDataHTML = await empProjectsData.text();
    console.log(empSelection.value);
    console.log(projectsDataHTML);
    console.log("Hello World");

    projectSelection.innerHTML = projectsDataHTML;
    projectItemSelection = document.getElementById("projNum");


    var empHoursData =  await fetch("http://localhost:5142/project/EditEmpHours_ProjHours/" + empSelection.value + "/" + projectItemSelection.value);
    var hoursDataHTML = await empHoursData.text();
    hourSelection.innerHTML = hoursDataHTML;
    hourItemSelection = document.getElementById("Hours");


    projectItemSelection.addEventListener("change", async () => {
        empHoursData = await fetch("http://localhost:5142/project/EditEmpHours_ProjHours/" + empSelection.value + "/" + projectItemSelection.value);
        hoursDataHTML = await empHoursData.text();
        console.log(" " + empSelection.value + " " + projectItemSelection.value);
        console.log(hoursDataHTML);

        hourSelection.innerHTML = hoursDataHTML;
        hourItemSelection = document.getElementById("Hours");
    })

});
