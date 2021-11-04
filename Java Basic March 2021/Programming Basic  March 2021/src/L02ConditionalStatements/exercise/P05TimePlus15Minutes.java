package L02ConditionalStatements.Exercise;

import java.util.Scanner;

public class P05TimePlus15Minutes {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int hour = Integer.parseInt(scanner.nextLine());
        int minutes = Integer.parseInt(scanner.nextLine());

        minutes += 15;

        if (minutes >= 60) {
            hour++;
            minutes -= 60;
        }
        if (hour > 23) {
            hour = 0;
        }

        System.out.printf("%d:%02d", hour, minutes);
    }
}
