import java.util.Scanner;

public class P06UniquePINCodes {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int endD1 = Integer.parseInt(scanner.nextLine());
        int endD2 = Integer.parseInt(scanner.nextLine());
        int endD3 = Integer.parseInt(scanner.nextLine());

        for (int d1 = 2; d1 <= endD1; d1 += 2) {
            for (int d2 = 2; d2 <= endD2; d2++) {
                for (int d3 = 2; d3 <= endD3; d3 += 2) {

                    boolean isD2Prime = true;
                    int limit = (int) Math.sqrt(d2);
                    for (int i = 2; i <= limit; i++) {
                        if (d2 % i == 0) {
                            isD2Prime = false;
                        }
                    }

                    if (isD2Prime) {
                        System.out.printf("%d %d %d%n", d1, d2, d3);
                    }
                }
            }
        }
    }
}
