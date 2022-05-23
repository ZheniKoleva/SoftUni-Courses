package L03ConditionalStatementsAdvanced.exercise;

import java.util.Scanner;

public class P07HotelRoom {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String month = scanner.nextLine().toLowerCase();
        int nightCount = Integer.parseInt(scanner.nextLine());

        double studioPrice = 0.00;
        double apartmentPrice = 0.00;

        switch (month) {
            case "may":
            case "october":
                studioPrice = 50.00;
                apartmentPrice = 65.00;
                if (nightCount > 7 && nightCount < 15 ) {
                    studioPrice -= studioPrice * 0.05;
                }else if (nightCount >= 15) {
                    studioPrice -= studioPrice * 0.30;
                    apartmentPrice -= apartmentPrice * 0.10;
                }

                break;
            case "june":
            case "september":
                studioPrice = 75.20;
                apartmentPrice = 68.70;
                if (nightCount >= 15) {
                    studioPrice -= studioPrice * 0.20;
                    apartmentPrice -= apartmentPrice * 0.10;
                }
                break;
            case "july":
            case "august":
                studioPrice = 76.00;
                apartmentPrice = 77.00;
                if (nightCount >= 15) {
                    apartmentPrice -= apartmentPrice * 0.10;
                }
                break;
        }
        double studioTotal = studioPrice * nightCount;
        double apartmentTotal = apartmentPrice * nightCount;
        System.out.printf("Apartment: %.2f lv.%n" + "Studio: %.2f lv.",
                           apartmentTotal, studioTotal);
    }
}
