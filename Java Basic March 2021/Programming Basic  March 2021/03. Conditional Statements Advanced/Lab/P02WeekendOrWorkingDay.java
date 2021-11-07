package L03ConditionalStatementsAdvanced.lab;

import java.util.Scanner;

public class P02WeekendOrWorkingDay {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String dayOfWeek = scanner.nextLine();
        String output = null;

        switch (dayOfWeek) {
            case "Monday":
            case "Tuesday":
            case "Wednesday":
            case "Thursday":
            case "Friday":
                output = "Working day";
                break;
            case "Saturday":
            case "Sunday":
                output = "Weekend";
                break;
            default:
                output = "Error";
                break;
        }
        System.out.println(output);
    }
}
