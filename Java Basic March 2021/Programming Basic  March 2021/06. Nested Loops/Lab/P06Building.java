package L06NestedLoops.lab;

import java.util.Scanner;

public class P06Building {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int floorsCount = Integer.parseInt(scanner.nextLine());
        int roomsCount = Integer.parseInt(scanner.nextLine());

        for (int floor = floorsCount; floor >= 1 ; floor--) {
            for (int room = 0; room < roomsCount; room++) {

                if (floor == floorsCount) {
                    System.out.printf("L%d%d ", floor, room);
                }else if (floor % 2 == 0) {
                    System.out.printf("O%d%d ", floor, room);
                }else {
                    System.out.printf("A%d%d ", floor, room);
                }
            }
            System.out.println();
        }
    }
}
