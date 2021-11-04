package L01FirstStepInCoding.exercise;

import java.util.Scanner;

public class P01UsdToBgn {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double usd = Double.parseDouble(scanner.nextLine());
        double rate = 1.79549;
        double bgn = usd * rate;

        System.out.println(bgn);
    }
}
