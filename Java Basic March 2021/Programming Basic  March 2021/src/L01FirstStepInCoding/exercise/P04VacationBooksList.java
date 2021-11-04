package L01FirstStepInCoding.exercise;

import java.util.Scanner;

public class P04VacationBooksList {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int bookPagesCount = Integer.parseInt(scanner.nextLine());
        int pagesPerHour = Integer.parseInt(scanner.nextLine());
        int daysCount = Integer.parseInt(scanner.nextLine());

        int hoursForBook = bookPagesCount / pagesPerHour;
        int hoursToReadPerDay = hoursForBook / daysCount;
        System.out.println(hoursToReadPerDay);
    }
}
