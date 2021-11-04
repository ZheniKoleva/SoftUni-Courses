import java.util.Scanner;

public class P01PCStore {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double processorPrice = Double.parseDouble(scanner.nextLine());
        double videoCardPrice = Double.parseDouble(scanner.nextLine());
        double memoryPrice = Double.parseDouble(scanner.nextLine());
        int memoryCount = Integer.parseInt(scanner.nextLine());
        double discount = Double.parseDouble(scanner.nextLine());

        double rateUSDtoBGN = 1.57;

        double totalSum = processorPrice + videoCardPrice;
        totalSum -= totalSum * discount;
        totalSum += memoryCount * memoryPrice;
        totalSum *= rateUSDtoBGN;

        System.out.printf("Money needed - %.2f leva.", totalSum);
    }
}
