package L06NestedLoops.moreExercise;

import java.util.Scanner;

public class P07SafePasswordsGenerator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int endX = Integer.parseInt(scanner.nextLine());
        int endY = Integer.parseInt(scanner.nextLine());
        int maxCount = Integer.parseInt(scanner.nextLine());

        int counter = 0;
        char a = 35;
        char b = 64;

        label:
        for (int x = 1; x <= endX; x++) {
            for (int y = 1; y <= endY; y++) {

              System.out.printf("%c%c%d%d%c%c|", a, b, x, y, b, a);
              counter++;

              if (counter == maxCount) {
                break label;
              }
              a++;
              b++;

              if (a > 55) {
                a = 35;
              }
              if (b > 96) {
                  b = 64;
              }

            }
        }
    }
}
