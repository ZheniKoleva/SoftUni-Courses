package L02ConditionalStatements.MoreExercise;

import java.util.Scanner;

public class P05Firm {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int hourForProject = Integer.parseInt(scanner.nextLine());
        int daysHave = Integer.parseInt(scanner.nextLine());
        int workersCountOvertime = Integer.parseInt(scanner.nextLine());

        double workHours = (daysHave * 8) * 0.90;
        double hoursOvertime = workersCountOvertime * daysHave * 2;
        double totalHours = Math.floor(workHours + hoursOvertime);
        double difference = Math.abs(totalHours - hourForProject);

        if (totalHours >= hourForProject) {
            System.out.printf("Yes!%.0f hours left.", difference);
        }else {
            System.out.printf("Not enough time!%.0f hours needed.", difference);
        }
    }
}
