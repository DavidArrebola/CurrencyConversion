import axios from "axios";

const BASE_URL = "http://localhost:5051";

export const convertCurrency = async (value: string): Promise<string> => {
  try {
    const { data: response } = await axios.post(
      `${BASE_URL}/currencyConversion`,
      {
        value,
      }
    );
    return response;
  } catch (error) {
    console.error("Error during currency conversion:", error);
    throw error;
  }
};
