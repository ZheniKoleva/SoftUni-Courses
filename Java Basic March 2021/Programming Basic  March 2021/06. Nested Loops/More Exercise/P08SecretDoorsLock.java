package L06NestedLoops.moreExercise;

import java.util.Scanner;

public class P08SecretDoorsLock {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int endHundreds = Integer.parseInt(scanner.nextLine());
        int endTenths = Integer.parseInt(scanner.nextLine());
        int endOnes = Integer.parseInt(scanner.nextLine());

        for (int hundreds = 2; hundreds <= endHundreds; hundreds += 2) {
            for (int tenths = 2; tenths <= endTenths; tenths++) {
                for (int ones = 2; ones <= endOnes; ones += 2) {

                    boolean isTenthsPrime = true;
                    for (int i = 2; i <= Math.sqrt(tenths) ; i++) {
                        if (tenths % i == 0) {
                            isTenthsPrime = false;
                        }
                    }

                    if (isTenthsPrime) {
                        System.out.printf("%d %d %d%n", hundreds, tenths, ones);
                    }
                }
            }
        }
    }
}
