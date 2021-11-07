package L06NestedLoops.moreExercise;

import java.util.Scanner;

public class P06WeddingSeats {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        char endSector = scanner.nextLine().charAt(0);
        int rowsCount = Integer.parseInt(scanner.nextLine());
        int seatsOddRow = Integer.parseInt(scanner.nextLine());

        int seatEvenRow = seatsOddRow + 2;
        int counter = 0;

        for (char sector = 'A'; sector <= endSector ; sector++) {

            if (sector != 'A') {
                rowsCount++;
            }

            for (int row = 1; row <= rowsCount; row++) {

                if (row % 2 == 0) {
                    for (char seat = 'a'; seat < 'a' + seatEvenRow; seat++) {
                        System.out.printf("%c%d%c%n", sector, row, seat);
                        counter++;
                    }

                }else {
                    for (char seat = 'a'; seat < 'a' + seatsOddRow; seat++) {
                        System.out.printf("%c%d%c%n", sector, row, seat);
                        counter++;
                    }
                }
            }
        }

        System.out.println(counter);
    }
}
