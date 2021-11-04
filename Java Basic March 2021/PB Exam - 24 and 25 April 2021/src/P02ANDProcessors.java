import java.util.Scanner;

public class P02ANDProcessors {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int processorsNeeded = Integer.parseInt(scanner.nextLine());
        int employeesCount = Integer.parseInt(scanner.nextLine());
        int workDaysCount = Integer.parseInt(scanner.nextLine());

        int hoursPerDay = 8;
        int timePerProcessor = 3;
        double processorPrice = 110.10;

        int hourTotal = workDaysCount * hoursPerDay;
        double processorsMade = Math.floor((hourTotal * employeesCount) * 1.0 / timePerProcessor);

        double difference = Math.abs(processorsMade - processorsNeeded);
        double money = difference * processorPrice;

        if (processorsMade >= processorsNeeded) {
            System.out.printf("Profit: -> %.2f BGN", money);

        }else {
            System.out.printf("Losses: -> %.2f BGN", money);
        }
    }
}
