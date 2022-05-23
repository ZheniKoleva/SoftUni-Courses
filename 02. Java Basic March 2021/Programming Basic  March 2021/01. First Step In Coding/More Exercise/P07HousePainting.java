package L01FirstStepInCoding.moreExercise;

import java.util.Scanner;

public class P07HousePainting {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double houseHeight = Double.parseDouble(scanner.nextLine());
        double wallLength = Double.parseDouble(scanner.nextLine());
        double heightOfRoof = Double.parseDouble(scanner.nextLine());

        double doorWidth = 1.20;
        double doorHeight = 2.00;
        double doorArea = doorHeight * doorWidth;
        double windowsSide = 1.50;
        double windowArea = Math.pow(windowsSide, 2);

        double frondWallsArea = Math.pow(houseHeight, 2) * 2;
        double sideWallsArea = (houseHeight * wallLength) * 2;
        double wallsArea = (frondWallsArea - doorArea) + (sideWallsArea - (windowArea * 2));

        double roofArea = sideWallsArea + ((houseHeight * heightOfRoof) / 2) * 2;

        double greenPaintNeeded = wallsArea / 3.4;
        double redPaintNeeded =roofArea / 4.3;

        System.out.printf("%.2f \n%.2f", greenPaintNeeded, redPaintNeeded);
    }
}
