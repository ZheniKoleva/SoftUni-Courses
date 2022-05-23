package L03ConditionalStatementsAdvanced.moreExercise;

import java.util.Scanner;

public class P07SchoolCamp {
    public static void main(String[] args) {
       Scanner scanner = new Scanner(System.in);
       String season = scanner.nextLine().toLowerCase();
       String typeOfGroup = scanner.nextLine();
       int studentsCount = Integer.parseInt(scanner.nextLine());
       int nightCounts = Integer.parseInt(scanner.nextLine());

       double pricePerNight = 0.00;
       String sport = null;

        switch (season) {
            case "winter":
                if (typeOfGroup.equals("boys") || typeOfGroup.equals("girls")) {
                    pricePerNight = 9.60;
                    if (typeOfGroup.equals("boys")) {
                        sport = "Judo";
                    }else {
                        sport = "Gymnastics";
                    }
                }else {
                    pricePerNight = 10.00;
                    sport = "Ski";
                }
                break;

            case "spring":
                if (typeOfGroup.equals("boys") || typeOfGroup.equals("girls")) {
                    pricePerNight = 7.20;
                    if (typeOfGroup.equals("boys")) {
                        sport = "Tennis";
                    }else {
                        sport = "Athletics";
                    }
                }else {
                    pricePerNight = 9.50;
                    sport = "Cycling";
                }
                break;

            case "summer":
                if (typeOfGroup.equals("boys") || typeOfGroup.equals("girls")) {
                    pricePerNight = 15.00;
                    if (typeOfGroup.equals("boys")) {
                        sport = "Football";
                    }else {
                        sport = "Volleyball";
                    }
                }else {
                    pricePerNight = 20.00;
                    sport = "Swimming";
                }
                break;

        }

        double finalPrice = nightCounts * pricePerNight * studentsCount;
        if (studentsCount >= 50) {
            finalPrice -= finalPrice * 0.50;
        }else if (studentsCount >= 20) {
            finalPrice -= finalPrice * 0.15;
        }else if (studentsCount >= 10) {
            finalPrice -= finalPrice * 0.05;
        }

        System.out.printf("%s %.2f lv.", sport, finalPrice);
    }
}
