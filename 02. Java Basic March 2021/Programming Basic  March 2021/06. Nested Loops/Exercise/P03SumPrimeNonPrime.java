package L06NestedLoops.exercise;

import java.util.Scanner;

public class P03SumPrimeNonPrime {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int sumPrime = 0;
        int sumNonPrime = 0;

        String command = scanner.nextLine();
        while (!command.equals("stop")) {
            int currentNum = Integer.parseInt(command);

            if (currentNum < 0) {
                System.out.println("Number is negative.");

            } else if (currentNum == 2) {
                sumPrime += currentNum;

            } else if (currentNum == 1 || currentNum % 2 == 0) {
                sumNonPrime += currentNum;

            } else {
                boolean isPrime = true;
                for (int i = 3; i <= Math.sqrt(currentNum); i += 2) {
                    if (currentNum % i == 0) {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime) {
                    sumPrime += currentNum;
                } else {
                    sumNonPrime += currentNum;
                }
            }
            command = scanner.nextLine();
        }

        System.out.printf("Sum of all prime numbers is: %d%n"
                        + "Sum of all non prime numbers is: %d%n",
                sumPrime, sumNonPrime);
    }
}
