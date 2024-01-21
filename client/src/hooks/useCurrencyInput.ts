import { useState } from "react";

const useCurrencyInput = () => {
  const [value, setValue] = useState<string>("");
  const [error, setError] = useState<string>("");

  const handleChange = (inputValue: string) => {
    // only a single dash or decimal point and numeric characters that are 2 decimal places
    const regex = /^-?\d*\.?\d{0,2}$/;

    if (regex.test(inputValue)) {
      const numericValue = inputValue ? Number(inputValue) : 0;

      if (
        (numericValue >= -999999999999.99 && numericValue <= 999999999999.99) ||
        inputValue === "-"
      ) {
        setError("");
        setValue(inputValue);
      } else {
        setError(
          "Please enter a valid dollar amount (up to two decimal places, max value ±999,999,999,999.99)."
        );
      }
    } else {
      setError(
        "Please enter a valid dollar amount (up to two decimal places)."
      );
    }
  };
  const generateRandomValue = () => {
    const max = 999999999999.99;
    const randomNumber = Math.random() * (max * 2) - max;
    setValue(randomNumber.toFixed(2));
  };

  return {
    value,
    setValue,
    onChange: handleChange,
    generateRandomValue,
    error,
    setError,
  };
};

export default useCurrencyInput;
