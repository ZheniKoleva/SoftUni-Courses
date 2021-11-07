package L01FirstStepInCoding.moreExercise;

import java.util.Scanner;

public class P05TrainingLab {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double labLength= Double.parseDouble(scanner.nextLine());
        double labWidth = Double.parseDouble(scanner.nextLine());

        double aisleWidth = 1.00;
        int workPlacesTaken = 3;
        double workPlaceLength = 1.20;
        double workPlaceWidth = 0.70;

        double rowsCount = Math.floor(labLength / workPlaceLength);
        double columnsCount = Math.floor((labWidth - aisleWidth) / workPlaceWidth);

        double workPlacesCount = (rowsCount * columnsCount) - workPlacesTaken;
        System.out.printf("%.0f", workPlacesCount);
    }
}
