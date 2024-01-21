import React, { useRef, useState } from "react";
import Header from "../components/Header";
import InputBar from "../components/InputBar";
import { capitalizeFirstLetter } from "@/utils/capitaliseFirstLetter";

type InputBarRef = {
  handleConvertToText: () => void;
};

const Home: React.FC = () => {
  const [serverResponse, setServerResponse] = useState<string>("");
  const inputBarRef = useRef<InputBarRef>(null);

  const handleSendData = (data: string) => {
    setServerResponse(capitalizeFirstLetter(data));
  };

  const handleKeyDown = (event: React.KeyboardEvent) => {
    if (event.key === "Enter" && inputBarRef.current) {
      inputBarRef.current.handleConvertToText();
    }
  };

  return (
    <div onKeyDown={handleKeyDown} tabIndex={0} className="p-0">
      <Header />
      <main className="flex p-4 gap-8 justify-center">
        <div className="flex flex-col items-center border border-[#020810] rounded-md p-4 w-96">
          <InputBar onSend={handleSendData} />
        </div>
        <div className="border border-[#020810] p-4 w-1/3 rounded-md">
          <h2 className="text-lg font-semibold mb-2 text-[#000810]">Output</h2>
          {serverResponse && (
            <div className="mt-4 p-4 border-t-2 text-[#000810]">
              {serverResponse}
            </div>
          )}
        </div>
      </main>
    </div>
  );
};

export default Home;
