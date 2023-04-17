# World Problem

# Estimating Sales Revenue: A marketing manager wants to estimate the sales revenue of a new product based on its advertising budget. 
# They have collected data on the advertising budget and sales revenue for the first 6 months of the product's launch. 
# The manager can use this program to fit a simple linear regression model to the 
# data and estimate the sales revenue for the next 3 months based on the advertising budget for those months.

import numpy as np
import matplotlib.pyplot as plt
from scipy.stats import f
from sklearn.linear_model import LinearRegression
from sklearn.preprocessing import PolynomialFeatures


def chart_data():
    advertising_budget = np.array([100, 200, 300, 400, 500, 600, 700])
    sales_revenue = np.array([250, 430, 655, 820, 1150, 1280, 1480])
    return advertising_budget, sales_revenue

def fit_linear_regression():
    advertising_budget, sales_revenue = chart_data()
    x_mean = np.mean(advertising_budget)
    y_mean = np.mean(sales_revenue)
    x_diff = advertising_budget - x_mean
    y_diff = sales_revenue - y_mean
    slope = np.sum(x_diff * y_diff) / np.sum(x_diff ** 2)
    intercept = y_mean - slope * x_mean
    residuals = sales_revenue - (intercept + slope * advertising_budget)
    rss = np.sum(residuals ** 2)
    dof = len(advertising_budget) - 2
    s_squared = rss / dof
    se_slope = np.sqrt(s_squared / np.sum(x_diff ** 2))
    se_intercept = np.sqrt(s_squared * (1/len(advertising_budget) + x_mean**2 / np.sum(x_diff ** 2)))
    ci_slope = (slope - 2 * se_slope, slope + 2 * se_slope)
    ci_intercept = (intercept - 2 * se_intercept, intercept + 2 * se_intercept)
    r_squared = 1 - rss / np.sum(y_diff ** 2)
    
    # calculate F-statistic
    mse = rss / dof
    msr = np.sum((intercept + slope * advertising_budget - y_mean) ** 2) / 1  # 1 predictor variable
    f_statistic = msr / mse
    
    return slope, intercept, ci_slope, ci_intercept, r_squared, f_statistic

def main():
    slope, intercept, ci_slope, ci_intercept, r_squared, f_statistic = fit_linear_regression()
    advertising_budget, sales_revenue = chart_data()
    predicted_sales = intercept + slope * advertising_budget
    ci = np.zeros((len(advertising_budget), 2))
    for i in range(len(advertising_budget)):
        ci[i] = [predicted_sales[i] + ci_slope[0] * advertising_budget[i] + ci_intercept[0], predicted_sales[i] + ci_slope[1] * advertising_budget[i] + ci_intercept[1]]
    plt.scatter(advertising_budget, sales_revenue, label="Actual Sales")
    plt.plot(advertising_budget, predicted_sales, color="red", label="Predicted Sales")
    plt.fill_between(advertising_budget, ci[:, 0], ci[:, 1], color="grey", alpha=0.3, label="95% CI")
    plt.legend()
    plt.xlabel("Advertising Budget (in thousands)")
    plt.ylabel("Sales Revenue (in thousands)")
    plt.title("Linear Regression Model for Sales Revenue Estimation")
    plt.show()

    # print R-squared and F-statistic
    print(f"R-squared: {r_squared:.4f}")
    print(f"F-statistic: {f_statistic:.4f}")

    # prompt user to input new data points
    while True:
        new_budget_str = input("\nEnter a new advertising budget (in thousands) to get the predicted sales revenue (or type 'quit' to exit): ")
        if new_budget_str == "quit":
            break
        try:
            new_budget = float(new_budget_str)
        except ValueError:
            print("Invalid input. Please enter a valid number.")
            continue
        predicted_revenue = intercept + slope * new_budget
        print(f"Predicted sales revenue for an advertising budget of ${new_budget:.2f}k: ${predicted_revenue:.2f}k")

if __name__ == '__main__':
    main()

