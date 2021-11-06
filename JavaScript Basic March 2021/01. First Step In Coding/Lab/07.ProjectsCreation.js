function projectCreation(input) {
    let nameOfArchitect = input[0];
    let projectsCount = Number(input[1]);
    const timePerProject = 3;
    let hours = projectsCount * timePerProject;

    console.log(`The architect ${nameOfArchitect} will need ${hours} hours to complete ${projectsCount} project/s.`);
}
projectCreation(["George", "4"]);

projectCreation(["Sanya", "9"]);