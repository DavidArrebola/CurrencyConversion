import React, { forwardRef, useImperativeHandle } from "react";
import useCurrencyInput from "../../hooks/useCurrencyInput";
import Button from "../Button";
import { convertCurrency } from "../../api/apiService";

const InputBar = forwardRef(
  ({ onSend }: { onSend: (value: string) => void }, ref) => {
    const { value, onChange, error, generateRandomValue, setValue, setError } =
      useCurrencyInput();

    const handleClear = () => {
      setValue("");
      setError("");
      onSend("");
    };

    useImperativeHandle(ref, () => ({
      handleConvertToText,
    }));

    const handleConvertToText = async () => {
      try {
        const response = await convertCurrency(value);
        onSend(response);
      } catch (error) {
        setError(
          "Error converting currency. Please try check your input and try again."
        );
      }
    };

    return (
      <div className="w-full">
        <div className="flex items-center border-2 border-[#020810] rounded-md p-4 mb-4">
          <span className="text-[#febe11] mr-2 text-lg">$</span>
          <input
            type="text"
            value={value}
            onChange={(e) => onChange(e.target.value)}
            className="text-black text-xl flex-1"
            placeholder="0.00"
          />
        </div>
        <div className="h-6 mb-2">
          {error && <p className="text-red-500 text-xs">{error}</p>}
        </div>
        <div className="flex justify-between">
          <Button label="Random Number" onClick={generateRandomValue} />
          <Button label="Clear" onClick={handleClear} />
          <Button
            label="Convert To Text"
            disabled={!value}
            onClick={handleConvertToText}
          />
        </div>
      </div>
    );
  }
);

export default InputBar;
InputBar.displayName = "InputBar";
