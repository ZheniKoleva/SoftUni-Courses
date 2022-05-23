package L03ConditionalStatementsAdvanced.exercise;

import java.util.Scanner;

public class P08OnTimeForTheExam {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int examHour = Integer.parseInt(scanner.nextLine());
        int examMinute = Integer.parseInt(scanner.nextLine());
        int arrivalHour = Integer.parseInt(scanner.nextLine());
        int arrivalMinute = Integer.parseInt(scanner.nextLine());

        int examTime = examHour * 60 + examMinute;
        int arrivalTime = arrivalHour * 60 + arrivalMinute;

        boolean isOnTime = (examTime > arrivalTime) && (examTime - arrivalTime) <= 30;
        boolean isEarly = (examTime > arrivalTime) && (examTime - arrivalTime) > 30;
        boolean isLate = arrivalTime > examTime;

        int difference = Math.abs(examTime - arrivalTime);
        int hour = difference / 60;
        int min = difference % 60;

        if (isOnTime) {
            System.out.println("On time");
            if (difference != 0) {
                System.out.printf("%d minutes before the start", difference);
            }

        }else if (isEarly) {
            System.out.println("Early");
            if (hour == 0) {
                System.out.printf("%d minutes before the start", min);
            }else {
                System.out.printf("%d:%02d hours before the start", hour, min);
            }

        }else if (isLate) {
            System.out.println("Late");
            if (hour == 0) {
                System.out.printf("%d minutes after the start", min);
            }else {
                System.out.printf("%d:%02d hours after the start", hour, min);
            }
        }
    }
}
