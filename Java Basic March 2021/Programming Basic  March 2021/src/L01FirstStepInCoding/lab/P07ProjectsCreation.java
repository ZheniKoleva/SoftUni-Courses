package L01FirstStepInCoding.lab;

import java.util.Scanner;

public class P07ProjectsCreation {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String architectName = scanner.nextLine();
        int projectsCount = Integer.parseInt(scanner.nextLine());
        int hourPerProject = 3;
        int hoursTotal = projectsCount * hourPerProject;

        System.out.printf("The architect %s will need %d hours to complete %d project/s.",
                architectName, hoursTotal, projectsCount);
    }
}
