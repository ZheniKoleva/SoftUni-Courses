package L01FirstStepInCoding.exercise;

import java.util.Scanner;

public class P08FishTank {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int lenght = Integer.parseInt(scanner.nextLine());
        int width = Integer.parseInt(scanner.nextLine());
        int height = Integer.parseInt(scanner.nextLine());
        double percentTakenSpace = Double.parseDouble(scanner.nextLine());

        double fishTankVolume = (lenght * width * height) * 0.001;
        fishTankVolume -= fishTankVolume * (percentTakenSpace / 100);
        System.out.printf("%.2f", fishTankVolume);
    }
}
