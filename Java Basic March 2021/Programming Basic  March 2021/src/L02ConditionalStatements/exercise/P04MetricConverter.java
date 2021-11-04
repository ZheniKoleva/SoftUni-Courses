package L02ConditionalStatements.Exercise;

import java.util.Scanner;

public class P04MetricConverter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double value = Double.parseDouble(scanner.nextLine());
        String inputMetric = scanner.nextLine();
        String outputMetric = scanner.nextLine();

        if (inputMetric.equals("mm")) {
            value /= 1000;
        }else if (inputMetric.equals("cm")) {
            value /= 100;
        }

        if (outputMetric.equals("mm")) {
            value *= 1000;
        }else if (outputMetric.equals("cm")) {
            value *= 100;
        }
        System.out.printf("%.3f", value);
    }
}
