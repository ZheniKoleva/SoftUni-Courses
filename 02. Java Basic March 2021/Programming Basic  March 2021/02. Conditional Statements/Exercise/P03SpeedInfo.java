package L02ConditionalStatements.Exercise;

import java.util.Scanner;

public class P03SpeedInfo {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double speed = Double.parseDouble(scanner.nextLine());
        String output = "";

        if (speed <= 10) {
            output = "slow";
        }else if (speed <= 50) {
            output = "average";
        }else if (speed <= 150) {
            output = "fast";
        }else if (speed <= 1000) {
            output = "ultra fast";
        }else {
            output = "extremely fast";
        }

        System.out.println(output);
    }
}
