package L06NestedLoops.exercise;

import java.util.Scanner;

public class P01NumberPyramid {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int number = Integer.parseInt(scanner.nextLine());

        int counter = 1;
        label:
        for (int row = 1; row <= number; row++) {
            for (int column = 1; column <= row ; column++) {
                System.out.printf("%d ", counter);
                counter++;

                if (counter > number) {
                    break label;
                }
            }
            System.out.println();
        }
    }
}
