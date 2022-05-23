package L04ForLoop.moreExercise;

import java.util.Scanner;

public class P07FootballLeague {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int stadiumCapacity = Integer.parseInt(scanner.nextLine());
        int fansCount = Integer.parseInt(scanner.nextLine());

        int fansInSectorA = 0;
        int fansInSectorB = 0;
        int fansInSectorV = 0;
        int fansInSectorG = 0;

        for (int i = 0; i < fansCount; i++) {
            char sector = scanner.nextLine().charAt(0);

            switch (sector) {
                case 'A':
                    fansInSectorA++;
                    break;
                case 'B':
                    fansInSectorB++;
                    break;
                case 'V':
                    fansInSectorV++;
                    break;
                case 'G':
                    fansInSectorG++;
                    break;
            }
        }

        System.out.printf("%.2f%%%n" + "%.2f%%%n" + "%.2f%%%n" + "%.2f%%%n" + "%.2f%%",
                (1.0 * fansInSectorA / fansCount * 100), (1.0 * fansInSectorB / fansCount * 100),
                (1.0 * fansInSectorV / fansCount * 100), (1.0 * fansInSectorG / fansCount * 100),
                (1.0 * fansCount / stadiumCapacity * 100));
    }
}
